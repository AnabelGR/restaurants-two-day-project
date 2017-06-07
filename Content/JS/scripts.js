$(function () {
  $(".cuisine").each(function() {
    $(this).click(function(event) {
      clicked = $(this).attr('id');
      $(".rest-" + clicked).toggle();
      event.preventDefault();
    });
  });
});
