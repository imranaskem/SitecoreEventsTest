function createCommentItem(form, path) {
    var service = new ItemService({ url: '/sitecore/api/ssc/item' });
    var obj = {
        ItemName: 'comment -' + form.name.value,
        TemplateID: '{E39C9B4C-296F-4FA6-AD44-DA73E16E413E}',
        Name: form.name.value,
        Comment: form.comment.value
    };

    service.create(obj)
        .path(path)
        .execute()
        .then(function(item) {
            form.name.value = form.comment.value = '';
            window.alert('Thanks. Your message will show on the site shortly');
        })
        .fail(function(err) {
            window.alert(err);
        });
    event.preventDefault();
    return false;
}