namespace AdisBlog.Routes
{
    public static class Route
    {
        public const string PostsCreate = "users/{userId}/posts";
        public const string PostsGetAll = "posts";
        public const string PostsDelete = "posts/{postId}";
        public const string PostsGetSingle = "posts/{postId}";
        public const string CommentsCreate = "posts/{postId}/comments";

        public const string UsersRegister = "register";
    }
}