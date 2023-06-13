using Forum.App.Data.Models.Post;

namespace Forum.App.Data.Seeding
{
    class PostSeeder
    {
        internal ICollection<Post> GeneratePosts()
        {
            ICollection<Post> posts = new HashSet<Post>();
            Post currentPost;

            currentPost = new Post()
            {
                Id = 1,
                Title = "My first post",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam posuere massa mi, eu pulvinar est dapibus eleifend. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nunc tempor sagittis tempus. Aenean sem nibh, tempor sed tortor et, aliquet tincidunt justo. Aenean non nunc eu leo finibus malesuada. Ut eleifend gravida lacus, a egestas turpis consectetur eget. Praesent pretium pulvinar tempor. Aenean at dictum erat. In nisi augue, consequat quis venenatis a, auctor eget sapien. Sed sed orci quis erat eleifend auctor nec sed nulla. Sed aliquam imperdiet tellus, at ultrices nisi viverra vel. Nulla aliquam imperdiet ante et semper."
            };
            posts.Add(currentPost);

            currentPost = new Post()
            {
                Id = 2,
                Title = "My second post",
                Content = "Donec egestas nunc quis risus scelerisque luctus. Mauris vitae mattis sem, sed sodales orci. Nullam feugiat justo at malesuada suscipit. Nulla facilisi. Proin faucibus dapibus elit, eget fermentum nibh blandit non. Quisque vel tortor vel erat tincidunt laoreet lobortis a est. Etiam bibendum est at semper tempus. Pellentesque suscipit sed dolor ut faucibus."
            };
            posts.Add(currentPost);

            currentPost = new Post()
            {
                Id = 3,
                Title = "My third post",
                Content = "Nullam feugiat justo at malesuada suscipit. Nulla facilisi. Proin faucibus dapibus elit, eget fermentum nibh blandit non. Quisque vel tortor vel erat tincidunt laoreet lobortis a est. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla at bibendum dui, non laoreet lectus. Morbi ut laoreet ex. Cras. "
            };
            posts.Add(currentPost);

            return posts.ToArray(); 
        }
    }
}
