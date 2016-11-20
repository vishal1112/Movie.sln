$(document).ready(function () {
    var btnRefresh = $('#btnRefresh');
    $("#lstMovies").load("@(Url.Action('SearchMovie', 'Movies'))");

    btnRefresh.click(function (e) {
        var url = "/Movies/SearchMovie";
        window.location.href = url;
    });
});