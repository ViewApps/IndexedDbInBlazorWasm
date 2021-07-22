
using Blazor.IndexedDB.WebAssembly;
using Microsoft.JSInterop;

namespace IndexedDb.Data
{
    public class AppIndexedDb : Blazor.IndexedDB.WebAssembly.IndexedDb
    {
        public AppIndexedDb(IJSRuntime jSRuntime, string name, int version) : base(jSRuntime, name, version) { }
        public IndexedSet<User> Users { get; set; }
        public IndexedSet<Blog> Blogs { get; set; }
        public IndexedSet<Post> Posts { get; set; }
    }
}
