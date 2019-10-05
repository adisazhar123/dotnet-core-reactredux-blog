namespace AdisBlog.Routes
{
    public static class Route
    {
        public const string PostsCreate = "users/{userId}/posts";
        public const string PostsGetAll = "posts";
        public const string PostsDelete = "posts/{postId}";
        public const string PostsGetSingle = "posts/{postId}";
        public const string CommentsCreate = "posts/{postId}/comments";

        public const string CommentsGet = "posts/{postId}/comments";
        
        public const string UsersRegister = "register";
        public const string UsersLogin = "login";
        public const string UsersLogout = "logout";

        public const string UsersFollow = "users/follow";
        public const string UsersUnFollow = "users/unfollow";
    }
}