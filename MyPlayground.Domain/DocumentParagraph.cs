using System;
using System.Collections.Generic;
using System.Text;

namespace MyPlayground.Domain
{
    class DocumentParagraph
    {
        public int RelationId { get; set; }
        public int Level { get; set; }
        public int Status { get; set; }

        public Document Document { get; set; }
        public Paragraph Paragraph { get; set; }
    }
}
