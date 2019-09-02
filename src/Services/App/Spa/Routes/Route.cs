namespace AdisBlog.Routes
{
    public static class Route
    {
        public const string POSTS_CREATE = "users/{userId}/posts";
        public const string POSTS_GET_ALL = "posts";
        public const string POSTS_DELETE = "posts/{postId}";
        public const string POSTS_GET_SINGLE = "posts/{postId}";
        public const string COMMENTS_CREATE = "posts/{postId}/comments";
    }
}