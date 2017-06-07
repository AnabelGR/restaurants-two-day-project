$(function () {
  $(".cuisine").each(function() {
    $(this).click(function(event) {
      clicked = $(this).attr('id');
      $("#rest-" + clicked).show();
      console.log(clicked);
      event.preventDefault();
    });
  });
});
