using System;
using System.Collections.Generic;
using System.Text;

namespace MyPlayground.DataTransferObjects
{
    public class ParagraphDto
    {
        public virtual int Id { get; set; }
        public virtual int Version { get; set; }
        public virtual string Name { get; set; }
        public virtual string Text { get; set; }
    }
}
