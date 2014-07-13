function StationController($scope, $http) {

    $scope.loading = false;
    $scope.posts = { name: "", description: "" };
    $scope.createStation = false;
    $scope.chooseMusic = false;
    $scope.finished = false;

    $scope.station = {};

//    $http.get('/api/posts/').success(function (data) {
//        $scope.posts = data;
//        $scope.loading = false;
//    })
//    .error(function () {
//        $scope.error = "An Error has occured while loading posts!";
//        $scope.loading = false;
//    });

//    $scope.toggleEdit = function () {
//        $scope.editMode = !$scope.editMode;
//    };

    $scope.create = function () {
        $scope.error = null;
        $scope.loading = true;

        // hardcoding test user Id for now
        $scope.station.StationOwnerId = 1;

        $http.post('https://localhost:44300/api/Station/', $scope.station).success(function (data) {
            $scope.station.Id = data;
            $scope.loading = false;
            $scope.chooseMusic = true;
        }).error(function (data) {
            $scope.error = data.Message;
            $scope.loading = false;
        });
    };
}
