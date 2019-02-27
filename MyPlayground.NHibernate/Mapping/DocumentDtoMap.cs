using FluentNHibernate.Mapping;
using MyPlayground.DataTransferObjects;
using System;

namespace MyPlayground.NHibernate
{
    public class DocumentDtoMap : ClassMap<DocumentDto>
    {
        public DocumentDtoMap()
        {
            Table("Document");

            Id(x => x.Id);
            Map(x => x.Version);
            Map(x => x.Name);
            Map(x => x.Status);

            var paragraphs= HasMany(x => x.Paragraphs);
            paragraphs.KeyColumns.Add("DocumentId");
            paragraphs.KeyColumns.Add("DocumentVersion");
        }
    }
}
