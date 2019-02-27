using System;
using System.Collections.Generic;
using System.Text;

namespace MyPlayground.DataTransferObjects
{
    public class DocumentParagraphDto
    {
        public virtual int Id { get; set; }
        public virtual int RelationId { get; set; }
        public virtual int Level { get; set; }
        public virtual int Status { get; set; }

        public virtual int DocumentId { get; set; }
        public virtual int DocumentVersion { get; set; }

        //public virtual ParagraphDto Paragraph { get; set; }
    }
}
