// using Domain.DTOs;
// using Domain.Repositories;
// using Infrastructure.SQL.Database;
// using Infrastructure.SQL.Database.Entities;
// using Microsoft.AspNetCore.Identity;

// namespace Infrastructure.SQL.Repositories;

// public class UserRepository : IUserRepository
// {
//     private readonly ConfContext _confContext;
//     private readonly ApplicationDbContext _applicationDbContext;
//     private readonly UserManager<IdentityUser> _userManager;
//     private readonly RoleManager<IdentityRole> _roleManager;
//     public UserRepository(ConfContext confContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext applicationDbContext)
//     {
//         _confContext = confContext;
//         _userManager = userManager;
//         _roleManager = roleManager;
//         _applicationDbContext = applicationDbContext;
//     }
//     /* public async Task<string> CreateAttendeeAsync(UserRegisterModelDto userRegisterModelDto)
//     {
//         using (var confdb_transaction = await _confContext.Database.BeginTransactionAsync())
//         using (var applicationdb_transaction = await _applicationDbContext.Database.BeginTransactionAsync())

//         {
//             try
//             {
//                 var userExists = await _userManager.FindByNameAsync(userRegisterModelDto.Email);
//                 if (userExists != null)
//                     return "User already exists!";
//                 IdentityUser user = new()
//                 {
//                     Email = userRegisterModelDto.Email,
//                     SecurityStamp = Guid.NewGuid().ToString(),
//                     UserName = userRegisterModelDto.Email
//                 };
//                 await _userManager.CreateAsync(user, userRegisterModelDto.Password);
//                 var AttendeeEntity = new AttendeeEntity
//                 {
//                     FirstName = userRegisterModelDto.FirstName,
//                     LastName = userRegisterModelDto.LastName,
//                     ContactNumber = userRegisterModelDto.ContactNumber,
//                     Email = userRegisterModelDto.Email,
//                     Gender = userRegisterModelDto.Gender
//                 };
//                 await _confContext.Attendees.AddAsync(AttendeeEntity);
//                 await _confContext.SaveChangesAsync();
//                 confdb_transaction.Commit();
//                 applicationdb_transaction.Commit();
//                 // return AttendeeEntity.Id;
//                 return "User created successfully!";
//             }
//             catch (Exception ex)
//             {
//                 await confdb_transaction.RollbackAsync();
//                 await applicationdb_transaction.RollbackAsync();
//                 return ex.Message;
//             }
//         }
//     }
//     public async Task<string> CreateOrganizerAsync(UserRegisterModelDto userRegisterModelDto, string role)
//     {
//         using (var confdb_transaction = await _confContext.Database.BeginTransactionAsync())
//         using (var applicationdb_transaction = await _applicationDbContext.Database.BeginTransactionAsync())
//         {
//             try
//             {
//                 var userExists = await _userManager.FindByNameAsync(userRegisterModelDto.Email);
//                 if (userExists != null)
//                     return "User already exists!";
//                 IdentityUser user = new()
//                 {
//                     Email = userRegisterModelDto.Email,
//                     SecurityStamp = Guid.NewGuid().ToString(),
//                     UserName = userRegisterModelDto.Email
//                 };
//                 if (await _roleManager.RoleExistsAsync(role))
//                 {
//                     await _userManager.CreateAsync(user, userRegisterModelDto.Password);
//                     await _userManager.AddToRoleAsync(user, role);
//                     var OrganizerEntity = new OrganizerEntity
//                     {
//                         FirstName = userRegisterModelDto.FirstName,
//                         LastName = userRegisterModelDto.LastName,
//                         ContactNumber = userRegisterModelDto.ContactNumber,
//                         Email = userRegisterModelDto.Email,
//                         Gender = userRegisterModelDto.Gender
//                     };
//                     await _confContext.Organizers.AddAsync(OrganizerEntity);
//                     await _confContext.SaveChangesAsync();
//                     confdb_transaction.Commit();
//                     applicationdb_transaction.Commit();
//                     // return AttendeeEntity.Id;
//                     return "User created successfully!";
//                 }
//                 else
//                 {
//                     return "Role does not exist!";
//                 }
//             }
//             catch (Exception ex)
//             {
//                 await confdb_transaction.RollbackAsync();
//                 await applicationdb_transaction.RollbackAsync();
//                 return ex.Message;
//             }
//         }
//     } */
//     /* var OrganizerEntity = new OrganizerEntity
//     {
//         FirstName = userRegisterModelDto.FirstName,
//         LastName = userRegisterModelDto.LastName,
//         ContactNumber = userRegisterModelDto.ContactNumber,
//         Email = userRegisterModelDto.Email,
//         Gender = userRegisterModelDto.Gender
//     };
//     await _confContext.Organizers.AddAsync(OrganizerEntity);
//     await _confContext.SaveChangesAsync();
//     return OrganizerEntity.Id; */

//     public async Task<string> CreateUserAsync(UserRegisterModelDto userRegisterModelDto, string role)
//     {
//         using (var confdb_transaction = await _confContext.Database.BeginTransactionAsync())
//         using (var applicationdb_transaction = await _applicationDbContext.Database.BeginTransactionAsync())
//         {
//             try
//             {
//                 var userExists = await _userManager.FindByNameAsync(userRegisterModelDto.Email);
//                 if (userExists != null)
//                     return "User already exists!";
//                 IdentityUser user = new()
//                 {
//                     Email = userRegisterModelDto.Email,
//                     SecurityStamp = Guid.NewGuid().ToString(),
//                     UserName = userRegisterModelDto.Email
//                 };
//                 if (await _roleManager.RoleExistsAsync(role))
//                 {
//                     var result = await _userManager.CreateAsync(user, userRegisterModelDto.Password);
//                     if (!result.Succeeded)
//                     {
//                         return result.Errors.First().Description;
//                     }
//                     await _userManager.AddToRoleAsync(user, role);
//                     if (role == "Admin" || role == "RoomCoordinator")
//                     {
//                         OrganizerEntity OrganizerEntity = new OrganizerEntity
//                         {
//                             FirstName = userRegisterModelDto.FirstName,
//                             LastName = userRegisterModelDto.LastName,
//                             ContactNumber = userRegisterModelDto.ContactNumber,
//                             Email = userRegisterModelDto.Email,
//                             Gender = userRegisterModelDto.Gender
//                         };
//                         await _confContext.Organizers.AddAsync(OrganizerEntity);
//                         await _confContext.SaveChangesAsync();
//                         confdb_transaction.Commit();
//                         applicationdb_transaction.Commit();
//                         return "User created successfully!";
//                     }
//                     else if (role == "Attendee")
//                     {
//                         AttendeeEntity AttendeeEntity = new AttendeeEntity
//                         {
//                             FirstName = userRegisterModelDto.FirstName,
//                             LastName = userRegisterModelDto.LastName,
//                             ContactNumber = userRegisterModelDto.ContactNumber,
//                             Email = userRegisterModelDto.Email,
//                             Gender = userRegisterModelDto.Gender
//                         };
//                         await _confContext.Attendees.AddAsync(AttendeeEntity);
//                         await _confContext.SaveChangesAsync();
//                         confdb_transaction.Commit();
//                         applicationdb_transaction.Commit();
//                         return "User created successfully!";
//                     }
//                     else if (role == "Speaker")
//                     {
//                         SpeakerEntity SpeakerEntity = new SpeakerEntity
//                         {
//                             FirstName = userRegisterModelDto.FirstName,
//                             LastName = userRegisterModelDto.LastName,
//                             ContactNumber = userRegisterModelDto.ContactNumber,
//                             Email = userRegisterModelDto.Email,
//                             Gender = userRegisterModelDto.Gender
//                         };
//                         //Additional fields should be added here
//                         await _confContext.Speakers.AddAsync(SpeakerEntity);
//                         await _confContext.SaveChangesAsync();
//                         confdb_transaction.Commit();
//                         applicationdb_transaction.Commit();
//                         return "User created successfully!";
//                     }
//                     else
//                     {
//                         return "Something went wrong!";
//                     }
//                 }
//                 else
//                 {
//                     return "Role does not exist!";
//                 }
//             }
//             catch (Exception ex)
//             {
//                 await confdb_transaction.RollbackAsync();
//                 await applicationdb_transaction.RollbackAsync();
//                 return ex.Message;
//             }
//         }
//     }
// }