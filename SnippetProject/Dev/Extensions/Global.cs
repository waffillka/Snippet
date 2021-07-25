using System;
using SnippetProject.Models;

namespace SnippetProject.Dev.Extensions
{
    public static class Global
    {
        public static int PaginationSize => 10;

        public static Guid DefaultGuid => Guid.Parse("a1b2c3d4-test-guid-b123-testGuid1234");

        public static Tag[] DefaultTags =>
            new[]
            {
                new Tag {Id = DefaultGuid, Name = "tag 1"}, 
                new Tag {Id = DefaultGuid, Name = "tag 2"}
            };

        public static Language[] DefaultLanguages =>
            new[]
            {
                new Language {Id = DefaultGuid, Name = "language 1"},
                new Language {Id = DefaultGuid, Name = "language 2"}
            };
    }
}