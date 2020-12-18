(function () {
    app.controller('order', function ($scope, $http, $httpParamSerializerJQLike) {
        $scope.orderList = [];
        $scope.customerList = [];
        $scope.employeeList = [];
        $scope.shipName = "";
        $scope.customerId = "";
        $scope.employeeId = "";
        $scope.Init = function () {
            $http.get('/Order/GetOrderList').then(function (result) {
                $scope.orderList = result.data;
            });
            $http.get('/Order/GetCustomerList').then(function (result) {
                $scope.customerList = result.data;
            });
            $http.get('/Order/GetEmployeeList').then(function (result) {
                $scope.employeeList = result.data;
            });
        };
        $scope.Add = function (shipName) {
            var requestData = {
                shipName: $scope.shipName,
                customerId: $scope.customerId,
                employeeId: $scope.employeeId
            }
            $http({
                method: 'POST',
                url: '/Order/AddOrder',
                data: $httpParamSerializerJQLike(requestData),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).then(function (result) {
                $scope.Init();
                $scope.shipName = "";
                $scope.customerId = "";
                $scope.employeeId = "";
            });
        };
        $scope.Update = function (item, event, index) {
            var requestData = {
                shipName: $scope.shipName,
                customerId: $scope.customerId,
                employeeId: $scope.employeeId
            }
            var elements = angular.element(event.target).parent().parent().children();
            var requestOrder = {
                orderID: item.orderID,
                customerId: elements[0].value,
                employeeId: elements[1].value,
                shipName: elements[2].value
            }
            $http({
                method: 'POST',
                url: '/Order/UpdateOrder',
                data: $httpParamSerializerJQLike(requestOrder),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).then(function (result) {
                $scope.Init();
            });
        };
        $scope.Delete = function (item, index) {
            $http({
                method: 'POST',
                url: '/Order/DeleteOrder',
                data: $httpParamSerializerJQLike({ orderID: item.orderID }),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).then(function (result) {
                $scope.Init();
            });
        };
    });
}).call(angular)
