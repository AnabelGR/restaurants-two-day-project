$(function () {
  $(".cuisine").each(function() {
    $(this).click(function() {
      clicked = $(this).attr('id');
      $(".rest-" + clicked).toggle();
    });
  });
  $(".showForm").click(function(){
    console.log("fuck");
    $(".hideThis").show();
  });
});
