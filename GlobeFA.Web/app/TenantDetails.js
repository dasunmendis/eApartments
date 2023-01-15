/* Declare angular functions for Employee */
var app = angular.module("app", ['ui.bootstrap', 'ngResource']);

app.controller('EmployeeDetailsCtrl', ['$scope', '$location', 'ControllerFactory', EmployeeDetailsCtrl]);

app.factory('ControllerFactory', ['$http', function ($http) {
    return {
        getEmployeeData: function () {
            return $http.get('/Employees/GetAllEmployeesToGrid');
        },
        postEmployeeData: function (data) {
            return $http.post('/Employees/CreateOrUpdateEmployee', data);
        },
        deleteEmployeeData: function (data) {
            return $http.post('/Employees/DeleteEmployee', data);
        }
        //getEmploymentTypeData: function () {
        //    return $http.get('/Employees/GetAllEmploymentTypes');
        //}
    };
}]);

function EmployeeDetailsCtrl($scope, $location, fac) {
    var modalDiv = $('#modalEmployeeDetails');

    $scope.totalItems = 0;
    $scope.SHOW_ALL = false;

    //employee data get
    $scope.employee = {};
    $scope.empHistory = [];
    fac.getEmployeeData().success(function (data) {
        $scope.empHistory = data;
        $scope.totalItems = data.length;
        console.log(data);
    });

    $scope.predicate = 'id';
    $scope.reverse = true;
    $scope.currentPage = 1;
    $scope.order = function (predicate) {
        $scope.reverse = ($scope.predicate === predicate) ? !$scope.reverse : false;
        $scope.predicate = predicate;
    };

    //$scope.totalItems = $scope.empHistory.length;
    $scope.numPerPage = 5;
    $scope.paginate = function (value) {
        var begin = ($scope.currentPage - 1) * $scope.numPerPage;
        var end = begin + $scope.numPerPage;
        var index = $scope.empHistory.indexOf(value);
        return (begin <= index && index < end);
    };

    $scope.clearFilter = function () {
        $scope.search = {};
    }

    //open modal for new employee
    $scope.newEmployee = function () {
        $scope.openEmployeeModal();
    };
    //open modal for edit employee
    $scope.editEmployee = function (item) {
        $scope.openEmployeeModal(item);
    };
    //employee modal function
    $scope.openEmployeeModal = function (item) {
        $scope.employee = item || {};
        modalDiv.modal({
            show: true
        });
    };

    //new employee save
    $scope.sendEmployee = function () {
        fac.postEmployeeData($scope.employee).success(function (data) {
            var emp = $scope.empHistory.filter(function (n) {
                return data.Id == n.Id;
            });

            if (emp.length > 0) {
                emp[0] = data;
            } else {
                $scope.empHistory.push(data);
            }
            $scope.employee = {};
            //modalDiv.modal('hide');
            //$scope.reloadData();
            $scope.closeModal();
        });
    };

    $scope.reloadData = function () {
        fac.getEmployeeData().success(function (data) {
            $scope.empHistory = data;
            $scope.totalItems = data.length;
        });
    };

    //delete employee
    $scope.deleteEmployee = function (item) {
        $scope.employee = item;
        fac.deleteEmployeeData($scope.employee).success(function () {
            var index = $scope.empHistory.indexOf(item);
            if (index > -1)
                $scope.empHistory.splice(index, 1);
        });
    };

    $scope.closeModal = function () {
        modalDiv.modal('hide');
        $scope.reloadData();
    };

    //Bind data for dropdown - 'Gender'
    $scope.genderOptions = [
        { name: 'Male', value: 'Male' },
        { name: 'Female', value: 'Female' }
    ];

    //Bind data for dropdown - 'Title'
    $scope.titleOptions = [
        { name: 'Mr', value: 'Mr' },
        { name: 'Mrs', value: 'Mrs' },
        { name: 'Rev', value: 'Rev' }
    ];

    //Bind data for dropdown - 'MaritalStatus'
    $scope.maritalStatusOptions = [
        { name: 'Single', value: 'Single' },
        { name: 'Married', value: 'Married' },
        { name: 'Divorced', value: 'Divorced' },
        { name: 'Widowed', value: 'Widowed' }
    ];

};