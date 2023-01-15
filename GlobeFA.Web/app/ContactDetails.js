/* Declare angular functions for Contact */
var app = angular.module("app", ['ui.bootstrap', 'ngResource']);

app.controller('ContactDetailsCtrl', ['$scope', '$location', 'ControllerFactory', ContactDetailsCtrl]);

app.factory('ControllerFactory', ['$http', function ($http) {
    return {
        getContactData: function () {
            return $http.get('/Contacts/GetAllContactsToGrid');
        },
        postContactData: function (data) {
            return $http.post('/Contacts/CreateOrUpdateContact', data);
        },
        deleteEmployeeData: function (data) {
            return $http.post('/Employees/DeleteContact', data);
        }
        //getEmploymentTypeData: function () {
        //    return $http.get('/Employees/GetAllEmploymentTypes');
        //}
    };
}]);

function ContactDetailsCtrl($scope, $location, fac) {
    var modalDiv = $('#modalContactDetails');

    $scope.totalItems = 0;
    $scope.SHOW_ALL = false;

    //employee data get
    $scope.contact = {};
    $scope.contactHistory = [];
    fac.getContactData().success(function (data) {
        $scope.contactHistory = data;
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

    $scope.numPerPage = 5;
    $scope.paginate = function (value) {
        var begin = ($scope.currentPage - 1) * $scope.numPerPage;
        var end = begin + $scope.numPerPage;
        var index = $scope.contactHistory.indexOf(value);
        return (begin <= index && index < end);
    };

    $scope.clearFilter = function () {
        $scope.search = {};
    }

    //open modal for new contact
    $scope.newContact = function () {
        $scope.openContactModal();
    };
    //open modal for edit contact
    $scope.editContact = function (item) {
        $scope.openContactModal(item);
    };
    //contact modal function
    $scope.openContactModal = function (item) {
        $scope.contact = item || {};
        modalDiv.modal({
            show: true
        });
    };

    //new contact save
    $scope.sendContact = function () {
        fac.postContactData($scope.contact).success(function (data) {
            var conObj = $scope.contactHistory.filter(function (n) {
                return data.Id == n.Id;
            });

            if (conObj.length > 0) {
                conObj[0] = data;
            } else {
                $scope.contactHistory.push(data);
            }
            $scope.contact = {};
            modalDiv.modal('hide');
            $scope.reloadData();
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