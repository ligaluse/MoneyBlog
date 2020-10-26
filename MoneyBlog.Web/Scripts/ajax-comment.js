$(document).ready(function () {

    $('#buttonComment').click(function () {
        var ArticleId = $('#ArticleId').val();
        var UserId = $('#UserId').val();
        var Email = $('#Email').val();
        var Comment = $('#Comment').val();
        $.ajax({
            url: '/Article/CreateComment/',
            type: 'POST',
            datatype: "JSON",
            data: { articleId: ArticleId, userId: UserId, email: Email, comment: Comment },
            success: function (result) {html(result);
            }
        });
    });
});