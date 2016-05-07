(function($) {
  $(function () { 
      // Ajax - get first question from cache
      $.ajax({
        type: "POST",
        url: "/QuizStart/GetQuestion",
        data: { questionCounter: questionCounter },
        datatype: "JSON",
        success: function (data) {
          console.log("success");
          $("#questionName").text(data.Name);

          var replacedAction = $("#ajaxForm").attr("action").replace("_questionId_", data.Id);
          console.log(replacedAction);

          $("#ajaxForm").attr("action", replacedAction);
          console.log($("#ajaxForm").attr("action"));

          //$("#ajaxForm").attr("action", function() {
          //  return this.action.replace("_questionId_", data.Id);
          //});

          $("#ajaxForm").submit();
        }
      });    
    });
  })(jQuery);