function StationController($scope, $http) {

    $scope.loading = false;
    $scope.createStation = false;
    $scope.chooseMusic = false;
    $scope.choosePlaylists = false;
    $scope.finished = false;

    $scope.station = {};
    $scope.spotify = { userId: null, playlists: [] };
    
    $scope.create = function () {
        $scope.error = null;
        $scope.loading = true;

        // hardcoding test user Id for now
        $scope.station.StationOwnerId = 1;

        $http.post('/api/Station/', $scope.station).success(function (data) {
            $scope.station.Id = data;
            $scope.loading = false;
            $scope.chooseMusic = true;
        }).error(function (data) {
            $scope.error = data.Message;
            $scope.loading = false;
        });
    };

    $scope.getPlaylists = function () {
        $scope.error = null;
        $scope.loading = true;

        $http.get('/api/Playlist/Get?service=spotify&userId=' + $scope.spotify.userId).success(function (data) {
            $scope.spotify.playlists = data.data;
            $scope.loading = false;
            $scope.choosePlaylists = true;
        }).error(function (data) {
            $scope.error = data.Message;
            $scope.loading = false;
        });
    };

    $scope.addPlaylist = function(playlist) {
        playlist.Add = true;
        playlist.Loading = true;

        var model = { ServiceName: "spotify", PlaylistId: playlist.Id };

        $http.post('/api/Playlist', model).success(function (data) {
            playlist.Loading = false;
        }).error(function(data) {
            $scope.error = data.Message;
            playlist.Loading = false;
        });
    };

}
