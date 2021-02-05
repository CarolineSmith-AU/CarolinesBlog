class Blog_Post {
    constructor(obj) {
        this.ID = obj.BLOG_ID;
        this.Title = obj.TITLE;
        this.Date = obj.DATE;
        this.Text = obj.BLOG_TEXT;
        this.Type_Name = obj.TYPE_NAME;
        this.Type = obj.BLOG_TYPE;
        this.Image_URL = obj.IMAGE_URL;
        this.Tags = obj.TAGS;
    }
}

class Blogger_Data {
    constructor(obj) {
        this.ID = obj.BLOGGER_ID;
        this.Blog_Types = obj.BLOG_TYPES;
    }
}