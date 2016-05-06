(function($) {
  $(function () {

    // Ajax - get first question from cache
    $.ajax({
      type: "POST",
      url: '@Url.Action("GetQuestion","QuizStart")',
      data: JSON.stringify(questionCounter),
      datatype: "html",
      success: function(data) {
        console.log("success");
      }
    });
  });
})(jQuery);