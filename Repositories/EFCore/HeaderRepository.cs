using System.Linq;
using Entities.Models;
using Entities.RequestFeature;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore
{
    public class HeaderRepository : RepositoryBase<Header>, IHeaderRepository
    {
        public HeaderRepository(RepositoryContext context)
            : base(context) { }

        public async Task<Header> CreateHeader(Header header)
        {
            var headers = await FindAll(false).ToListAsync();
            header.Sort = headers.Count() + 1;
            Create(header);
            return header;
        }

        public Header DeleteHeader(Header header)
        {
            Delete(header);
            return header;
        }

        public Header UpdateHeader(Header header)
        {
            Update(header);
            return header;
        }

        public async Task<Header> SortHeaderAsync(int id, int newSort, bool trackChanges)
        {
            var header = await FindByCondition(h => h.HeaderID == id, trackChanges)
                .SingleOrDefaultAsync();
            var header2 = await FindByCondition(h => h.Sort == newSort, trackChanges)
                .SingleOrDefaultAsync();
            if (header2 != null)
            {
                header2.Sort = header.Sort;
                Update(header2);
            }
            header.Sort = newSort;
            Update(header);
            return header;
        }

        public async Task<IEnumerable<Header>> GetAllHeadersAsync(bool trackChanges)
        {
            var headers = await FindAll(trackChanges)
                .OrderBy(h => h.HeaderID)
                .Include(h => h.User)
                .ToListAsync();

            var rootHeaders = headers.Where(h => h.ParentHeaderID == null).ToList();

            foreach (var header in headers)
            {
                if (header.ParentHeaderID.HasValue)
                {
                    var parentHeader = headers.FirstOrDefault(h =>
                        h.HeaderID == header.ParentHeaderID.Value
                    );
                    parentHeader?.SubHeaders?.Add(header);
                }
            }

            return rootHeaders;
        }

        public async Task<Header> GetHeaderByIdAsync(int id, bool trackChanges)
        {
            var header = await FindByCondition(h => h.HeaderID == id, trackChanges)
                .Include(h => h.User)
                .SingleOrDefaultAsync();

            if (header != null)
            {
                var allHeaders = await FindAll(trackChanges).ToListAsync();

                var subHeaders = allHeaders
                    .Where(h => h.ParentHeaderID == header.HeaderID)
                    .ToList();

                if (subHeaders.Any())
                {
                    header.SubHeaders = subHeaders;
                }
            }

            return header;
        }
    }
}
