# api-conf-manage

Hosts the backend components for conference management system.
Front end is in Development using ReactJS (branch feature/add-client-app)

## User Stories

**As a conference attendee,**

1. I want to view the schedule for each day, including the list of speakers and their sessions,so that I can plan my attendance.

2. I want to see the list of speakers and their topics for each day,so that I can choose which sessions to attend.

3. I want to be able to register for the conference and select the sessions I plan to attend,so that I can ensure my spot in the session.

4. I want to receive notifications or reminders about the sessions I've registered for,so that I don't miss any of the sessions I'm interested in.

**As a conference organizer,**

1. I want to assign available rooms to speakers for their sessions,so that the each speaker has an allocated space.

2. I want to define the conference schedule for each day, so that attendees know when and where each session is happening.

3. I want to control the duration of each session, so that the schedule is organized.

4. I want to add speakers to the conference, so that they can conduct sessions.

5. I want to approve or reject attendee requests for specific sessions, so that I can manage session attendance.

6. I want to make changes to the schedule or room assignments, so that I can adapt to unforeseen circumstances.

## Entities

1. Room
   - Attributes: Room Number, Capacity, Availability
2. Speaker
   - Attributes: ID, First name, Last name, Gender Contact number, Email, University, Job title
3. Attendee
   - Attributes: ID ,First name, Last name, Contact number, Email, Gender
4. Session
   - Attributes: ID, Speaker, Room Number, Topic, Conf date, Start time, End time
5. Session_Attendee
   - Attributes: ID, Attendee, Session

### Entity Relationship Diagram

![ERD_Conference_Management](https://github.com/Sobikanth/api-conf-manage/assets/77259477/9fbede9a-fb50-403d-a635-335759f995f5)

## User Journey Map

### Attendee's Journey

![Customer journey map](https://github.com/Sobikanth/api-conf-manage/assets/77259477/a6694d41-26e2-43e8-a912-fd8a7def971d)

### Speaker's Journey

1. View schedule

   - Logs in and view the scheduled session.

     _Touchpoints - Conference dashboard_

2. Prepares

   - Access speaker resources.
   - Uploads presentation materials.

     _Touchpoints - Speaker's dashboard_

3. Delivers session

   - Delivers session either physically or virtually.

     _Touchpoints - On-site or virtual session platform_

### Room coordinator's Journey

1. View schedule

   - Logs in and view the scheduled session.

     _Touchpoints - Conference dashboard_

2. Room set up

   - Sets up room for sessions according to the availability.

     _Touchpoints - Room coordinator dashboard_

3. Post session clean up

   - Closes the session make the room available for coming session.

     _Touchpoints - Room coordinator dashboard_

### Organizer's / Administrator's Journey

1. Configure the system

   - Manages the user roles.
   - Configures system settings.

     _Touchpoints - Admin dashboard_

2. Manage user

   - Manages speakers, attendees and other users.

     _Touchpoints - Admin dashboard dashboard_
