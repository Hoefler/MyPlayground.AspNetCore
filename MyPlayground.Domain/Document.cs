using System;

namespace MyPlayground.Domain
{
    public class Document
    {
        public int Id { get; set; }
        public int Version { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
    }
}
