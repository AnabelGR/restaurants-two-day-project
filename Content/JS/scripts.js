$(function () {
  $(".cuisine").click(function(event) {
    $(".panel-body").toggle();
    event.preventDefault();
  });
});
