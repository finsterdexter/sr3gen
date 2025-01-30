using Microsoft.Extensions.Options;
using SR3Generator.Database.Connection;
using SR3Generator.Database.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3Generator.Database.Test.Queries
{
    public class ReadSkillsQueryTests
    {
        [Fact]
        public async Task HandleAsync_ShouldReturnResults()
        {
            var dbConnectionFactory = new DbConnectionFactory(Options.Create<DatabaseOptions>(new DatabaseOptions()));
            var conn = dbConnectionFactory.CreateConnection();
            var queryHandler = new ReadSkillsQueryHandler();
            var results = await queryHandler.HandleAsync(new ReadSkillsQuery(), conn, null!);

            Assert.NotEmpty(results.skills);
            Assert.NotEmpty(results.specializations);

        }
    }
}
