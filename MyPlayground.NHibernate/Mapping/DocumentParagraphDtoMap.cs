using FluentNHibernate.Mapping;
using MyPlayground.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPlayground.NHibernate.Mapping
{
    public class DocumentParagraphDtoMap : ClassMap<DocumentParagraphDto>
    {
        public DocumentParagraphDtoMap()
        {
            Table("DocumentParagraph");

            Id(x => x.Id);
            Map(x => x.RelationId);
            Map(x => x.Level);
            Map(x => x.Status);
        }
    }
}
