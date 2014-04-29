﻿using System;
using System.Linq;
using Radiostr.Entities;
using Radiostr.Helpers;
using Radiostr.Repositories;

namespace Radiostr.Services
{
    public class LibraryTrackService : RadiostrService<LibraryTrack>, ILibraryTrackService
    {
        internal LibraryTrackService(ISecurityHelper securityHelper, IRepository<LibraryTrack> repository) 
            : base(securityHelper, repository)
        {
        }

        public bool TrackExistsInLibrary(int trackId, int libraryId)
        {
            SecurityHelper.Authenticate();

            var results = Repository.Query(
                @"if exists (select 1 from LibraryTrack where LibraryId = @libraryId and TrackId = @trackId) 
                    select 1 as TrackExists 
                    else select 0 as TrackExists",
                new { libraryId, trackId }).ToList();
            return Convert.ToBoolean(results[0].TrackExists);
        }

        public LibraryTrack Get(int libraryId, int trackId)
        {
            SecurityHelper.Authenticate();
            
            var tracks = Repository.Query<LibraryTrack>(
                "select * from LibraryTrack where LibraryId = @libraryId and TrackId = @trackId",
                new {libraryId, trackId}).ToList();
            int count = tracks.Count();
            if (count == 0) return null;
            if (count > 1) throw new InvalidOperationException("LibraryTrack's should be unique by Library Id and Track Id.");
            return tracks[0];
        }

        public override LibraryTrack Get(int id)
        {
            throw new NotSupportedException("LibraryTrack has a composite Key. Use the other overload");
        }

        public override void Update(LibraryTrack model)
        {
            throw new NotImplementedException("LibraryTrack's are immutable.");
        }
    }
}