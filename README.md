# DeltaX
Assignment

Folder Structure
Controllers folder - consists of Movie, Actor and Producer controllers.
Database folder - consists of all the scripts to create table and stored procedure.
Models folder - Consists of all the Model class.
Repository folder - Consists of repository files for database interaction.
Service folder - Consists of service files for business logic.

Update the connection string in appsettings.json file and run the scripts present in the database folder.

There are total 8 endpoints.
1. Add Actor Endpoint for Add Actor window
method: POST
endpoint: https://localhost/api/actors

request:
{
  "id": 0,
  "name": "Darshan",
  "bio": "CS",
  "dob": "12-07-1978",
  "gender": "Male",
  "isActive": true,
  "isDeleted": false
}

response:
on successfull addition:
200 OK response
Actor added successfully.
On failure:
200 OK response
Failed to add the Actor.
On Invalid Id:
400 Bad Request

2. Get List of Actors to populate the list of actors in the drop down.
method: GET
endpoint: https://localhost/api/actors

response:
on success:
200 OK response
[
  {
    "id": 1,
    "name": "Yash",
    "bio": "RS",
    "dob": "12-09-1987",
    "gender": "Male",
    "isActive": true,
    "isDeleted": false
  },
  {
    "id": 3,
    "name": "Sanjay",
    "bio": "BABA",
    "dob": "12-08-1997",
    "gender": "Male",
    "isActive": true,
    "isDeleted": false
  }
]
on failure:
204 No Content Response

3. Add Producer endpoint for Add Producer Window
method: POST
endpoint: https://localhost/api/producers

request:
{
  "id": 0,
  "name": "David",
  "bio": "Prod",
  "dob": "12-03-1998",
  "company": "Dream Works",
  "gender": "Male",
  "isActive": true,
  "isDeleted": false
}

response:
on successfull addition:
200 OK response
Producer added successfully.
On failure:
200 OK response
Failed to add the Producer.
On Invalid Id:
400 Bad Request

4. Get List of Producers to populate list of producers in the dropdown.
method: GET
endpoint: https://localhost/api/producers

response:
on success:
200 OK response
[
  {
    "id": 3,
    "name": "Smith",
    "bio": "HW",
    "dob": "17-12-1980",
    "company": "Pixel",
    "gender": "Male",
    "isActive": true,
    "isDeleted": false
  },
  {
    "id": 4,
    "name": "Lily",
    "bio": "HW",
    "dob": "12-08-1998",
    "company": "Dream Works",
    "gender": "Female",
    "isActive": true,
    "isDeleted": false
  }
]
on failure:
204 No Content Response

5. Add Movie endpoint for add movie window
method: POST
endpoint: https://localhost/api/movies

request: multipart/form-data

key: Name value: string
key: Plot value: string
key: Date value: string => DD-MM-YYYY format
key: Producer value: integer($int32) => Producer id
key: Actors value: string => comma seperated actors ids
key: Poster value: string($binary) =>image file

response:
on successfull addition:
200 OK response
Movie added successfully.
On failure:
200 OK response
Failed to add the Movie.
On Invalid Id:
400 Bad Request

6. Get Movie endpoint to get list of movies for landing page.

method: GET
endpoint: https://localhost/api/movies

response:
[
  {
    "id": 6,
    "name": "Beast",
    "plot": "a b  c d",
    "date": "18-09-1998",
    "producer": "David",
    "actors": [
      {
        "name": "Sanjay",
        "id": 3
      }
    ],
    "posterName": "LOGO_png_without_border.png",
    "posterData": "iVBORw0KGgoAAAANSUhEgg==uxuexuinsix"   => Byte[]
  },
  {
    "id": 7,
    "name": "A",
    "plot": "abcd",
    "date": "18-09-1998",
    "producer": "David",
    "actors": [
      {
        "name": "Yash",
        "id": 1
      },
      {
        "name": "Srinidhi",
        "id": 2
      },
      {
        "name": "Sanjay",
        "id": 3
      },
      {
        "name": "Darshan",
        "id": 4
      }
    ],
    "posterName": "LOGO.png",
    "posterData": "iVBORw0KGgoAA5CYII="   => Byte[]
  }
]

200 OK response
on failure:
204 No Content Found
on Invalid Request
400 Bad Request

7. Update Movie endpoint for movie Update window
method: PUT
endpoint:https://localhost/api/movies/{id}

request:  			multipart/form-data
key: Name value: string
key: Plot value: string
key: Date value: string => DD-MM-YYYY format
key: Producer value: integer($int32) => Producer id
key: Actors value: string => comma seperated actors ids
key: Poster value: string($binary) =>image file

response:
on successfull addition:
200 OK response
Movie updated successfully.
On failure:
200 OK response
Failed to update the Movie or Particular Movie Not Found
On Invalid Id:
400 Bad Request

8. Delete movie endpoint for delete movie option
method: DELETE
endpoint:https://localhost/api/movies/{id}

soft delete

response:
on successfull addition:
200 OK response
Movie deleted successfully.
On failure:
200 OK response
Failed to Delete the Movie or Particular movie not found
On Invalid Id:
400 Bad Request
