using System.Collections.Generic;

namespace MyPlayground.DataTransferObjects
{
    public class DocumentDto
    {
        public virtual int Id { get; set; }
        public virtual int Version { get; set; }
        public virtual string Name { get; set; }
        public virtual int Status { get; set; }

        public virtual int DocumentId { get; set; }
        public virtual int DocumentVersion { get; set; }
        public virtual IList<DocumentParagraphDto> Paragraphs { get; set; }
    }
}
