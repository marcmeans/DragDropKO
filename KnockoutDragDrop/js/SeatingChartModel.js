//add animation for messages appearing and fading away
ko.bindingHandlers.flash = {
    init: function (element) {
        $(element).hide();
    },
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        if (value) {
            $(element).stop().hide().text(value).fadeIn(function () {
                clearTimeout($(element).data("timeout"));
                $(element).data("timeout", setTimeout(function () {
                    $(element).fadeOut();
                    valueAccessor()(null);
                }, 3000));
            });
        }
    },
    timeout: null
};

var SeatingChartModel = function (incomingModel) {
    var self = this;
    this.tables = ko.mapping.fromJS(incomingModel.tables);
    this.availableStudents = ko.mapping.fromJS(incomingModel.availableStudents, mappingOptions);
    this.trash = ko.observableArray([]);
    this.lastAction = ko.observable();
    this.lastError = ko.observable();
    this.maximumStudents = 4;
    this.isTableAvailable = function (parent) {
        return parent().length < self.maximumStudents;
    };
    this.isTable = function (arg) {
        return arg.sourceParent != undefined;
    };

    
    this.updateLastAction = function (arg) {
        var newPriority = arg.targetIndex;
        var source;
        var target;
        var origStudentId = arg.item.id();
        
        //set source
        if (arg.sourceParent) {
            source = ko.utils.arrayFirst(self.tables(), function (tbl) {
                return tbl.students() === arg.sourceParent();
            });
        }
        if (!source) {
            //if source wasn't found, must be available students
            source = self.availableStudents;
            //create new id for object since it's a copy from draggable
            arg.item.id(generateGuid());
        }

        //set target
        target = ko.utils.arrayFirst(self.tables(), function (tbl) {
            return tbl.students() === arg.targetParent();
        });
        if (!target) {
            target = self.availableStudents;
        }

        //change priority on UI
        $.each(target.students(), function (i, val) {
            val.priority(i);
        });

        //show success message
        self.lastAction("Moved " + arg.item.name() + " from " + source.name() + " (seat " + (arg.sourceIndex + 1) + ") to " + target.name() + " (seat " + (arg.targetIndex + 1) + ")");

        //make server call to save action
        $.ajax({
            url: "Home/AdjustPriority",
            type: "POST",
            data: {
                studentId: origStudentId,
                newStudentId: arg.item.id(),
                priority: newPriority,
                sourceId: source.id(),
                targetId: target.id()
            }
        });
    };

    //verify that if a fourth member is added, there is at least one member of each gender
    this.verifyAssignments = function (arg) {
        var gender,
            parent = arg.targetParent;

        if (parent.id !== "Available Students" && parent().length === 3 && parent.indexOf(arg.item) < 0) {
            gender = arg.item.gender();
            if (!ko.utils.arrayFirst(parent(), function (student) { return student.gender() !== gender; })) {
                //show error message
                self.lastError("Cannot move " + arg.item.name() + " to " + arg.targetParent.id + " because there would be too many " + gender + " students");
                arg.cancelDrop = true;
            }
        }

    };

    //find table where student resides and remove with animation
    this.removeStudent = function (data, event) {
        var table = ko.utils.arrayFirst(self.tables(), function (tbl) {
            if ($.inArray(data, tbl.students()) > -1) {
                return tbl;
            }
            return null;
        });
        if (table) {
            $("#" + event.toElement.parentNode.id).slideUp(function () {
                table.students.remove(data);
                $.ajax({
                    url: "Home/RemoveStudent",
                    type: "POST",
                    data: {
                        studentId: data.id(),
                        sourceId: table.id()
                    }
                });
            });
        }
    };

};

//used for generating unique id for clients to pass
function generateGuid() {
    var result, i, j;
    result = '';
    for (j = 0; j < 32; j++) {
        if (j == 8 || j == 12 || j == 16 || j == 20)
            result = result + '-';
        i = Math.floor(Math.random() * 16).toString(16).toUpperCase();
        result = result + i;
    }
    return result;
}

//overriding clone function so that draggables are unique
var mappingOptions = {
    students: {
        create: function (options) {
            var result = ko.mapping.fromJS(options.data);
            result.clone = function() {
                return ko.mapping.fromJS(ko.mapping.toJS(this));
            };
            return result;
        }
    }
};