using FluentNHibernate.Mapping;
using MyPlayground.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPlayground.NHibernate.Mapping
{
    public class ParagraphDtoMap : ClassMap<ParagraphDto>
    {
        public ParagraphDtoMap()
        {
            Table("Paragraph");

            Id(x => x.Id);
            Map(x => x.Version);
            Map(x => x.Name);
            Map(x => x.Text);
        }
    }
}
