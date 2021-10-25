using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Settings
{
    public interface IDatabaseSettings
    {
        public string CourseColletionName { get; set; }
        public string CategroyCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
