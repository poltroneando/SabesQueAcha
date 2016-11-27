

$('.form-container label').each(function () {
    var getTitle = $(this).html();
    $(this).parent().find('input').attr('placeholder', getTitle)

});




