// using mapis.Domain;
// using mapis.Infrastructure;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace mapis.Services
// {
//     public class Event : IEvents
//     {
//         private readonly ApplicationDbContext _context;

//         public Event(ApplicationDbContext context)
//         {
//             _context = context;
//         }
//         public async Task<CreatedResponse> AddEvent(UploadEvent request)
//         {
//             var existingEvent = await _context.Events
//                 .FirstOrDefaultAsync(e => e.EventName == request.EventName && e.StartDate == request.StartDate);

//             if (existingEvent != null)
//             {
//                 return new CreatedResponse
//                 {
//                     Success = false,
//                     StatusCode = 400,
//                     Message = $"Event {request.EventName} is Already Added on "
//                 };
//             }


//             var newEvent = new Events
//             {
//                 EventId = Guid.NewGuid(),
//                 EventName = request.EventName,
//                 EventType = request.EventType,
//                 Venue = request.Venue,
//                 StartTime = request.StartTime,
//                 EndTime = request.EndTime,
//                 StartDate = request.StartDate,
//                 EndDate = request.EndDate,

//             };

//             _context.Events.Add(newEvent);
//             await _context.SaveChangesAsync();

//             return new CreatedResponse
//             {
//                 Success = true,
//                 StatusCode = 200,
//                 Message = "Event Added Successfully"
//             };
//         }


//         public async Task<List<AllEvents>> GetEvents()
//         {
//             var allEvents = await _context.Events
//                 .Select(e => new AllEvents
//                 {
//                     EventId = e.EventId,
//                     EventName = e.EventName,
//                     EventType = e.EventType,
//                     Venue = e.Venue,
//                     StartTime = e.StartTime,
//                     StartDate = e.StartDate,
//                     EndDate = e.EndDate,
//                     EndTime = e.EndTime,
//                     Status = e.Status
//                 })
//                 .ToListAsync();

//             return allEvents;
//         }

//         public async Task<CreatedResponse> RegisterEvent(Guid eventId,  RegisterEvent request)
//         {
//            var eventExist = _context.Events.FirstOrDefault(e=>e.EventId == eventId);
//             if (eventExist == null)
//             {
//                 return new CreatedResponse
//                 {
//                     Success = false,
//                     StatusCode = 404,
//                     Message = "Could not Find Event"
//                 };
//             }

//            var existingRegistration = await _context.RegisterEvents.FirstOrDefaultAsync(e=>e.CILTUserId == request.CILTUserId && e.EventId == eventId);
//            if(existingRegistration != null)
//            {
//             return new CreatedResponse 
//             {
//                 Success = false,
//                 StatusCode = 404,
//                 Message = "Event Already Registered"
//             };
            
//            }
//            var registerEvent = new EventRegistration
//             {
//                 EventRegistrationId = Guid.NewGuid(),
//                 CILTUserId = request.CILTUserId,
//                 EventId = eventId,
//             };
//             await _context.RegisterEvents.AddAsync(registerEvent);
//             await _context.SaveChangesAsync();

//             return new CreatedResponse
//             {
//                 Success = true,
//                 StatusCode = 201,
//                 Message = "Event Registerd Successfully"
//             };
//         }

       

//         public async Task<CreatedResponse> UpdateEvent(Guid EventId, UpdateEvent request)
//         {
//             var eventExist = await _context.Events.FirstOrDefaultAsync(e => e.EventId == EventId);
//             if (eventExist == null)
//             {
//                 return new CreatedResponse
//                 {
//                     Success = false,
//                     StatusCode = 404,
//                     Message = "Event not available"
//                 };
//             }
//             int changes = 0;
//             if (!string.IsNullOrEmpty(request.EventName) && request.EventName != eventExist.EventName)
//             {
//                 eventExist.EventName = request.EventName;
//                 changes++;
//             }

//             if (!string.IsNullOrEmpty(request.EventType) && request.EventType != eventExist.EventType)
//             {
//                 eventExist.EventType = request.EventType;
//                 changes++;
//             }

//             if (!string.IsNullOrEmpty(request.Venue) && request.Venue != eventExist.Venue)
//             {
//                 eventExist.Venue = request.Venue;
//                 changes++;
//             }

//             if (!string.IsNullOrEmpty(request.StartTime) && request.StartTime != eventExist.StartTime)
//             {
//                 eventExist.StartTime = request.StartTime;
//                 changes++;
//             }

//             if (!string.IsNullOrEmpty(request.EndTime) && request.EndTime != eventExist.EndTime)
//             {
//                 eventExist.EndTime = request.EndTime;
//                 changes++;
//             }

//             if (!string.IsNullOrEmpty(request.StartDate))
//             {
//                 eventExist.StartDate = request.StartDate;
//                 changes++;
//             }

//             if (!string.IsNullOrEmpty(request.EndDate))
//             {
//                 eventExist.EndDate = request.EndDate;
//                 changes++;
//             }

//             if (!string.IsNullOrEmpty(request.Status) && request.Status != eventExist.Status)
//             {
//                 eventExist.Status = request.Status;
//                 changes++;
//             }
//             await _context.SaveChangesAsync();
//             if (changes == 0)
//             {
//                 return new CreatedResponse
//                 {
//                     Success = false,
//                     StatusCode = 400,
//                     Message = "No Changes were made"
//                 };
//             }
//             return new CreatedResponse
//             {
//                 Success = true,
//                 StatusCode = 200,
//                 Message = "Event updated successfully"
//             };
//         }
//     }
// }