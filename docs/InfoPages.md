# Info Pages
## Endpoints
### Get Info Page List
- **Short Description:** Gets course's section's info page list. Returns hidden info pages if owner.
- **URL:** `/courses/{courseId}/sections/{sectionId}/infoPages`
- **Method:** `GET`
- **Require Authorization:** `optional`
- **Authorized Roles:** `CREATOR`
- **Request Type:**
  - `courseId`: int
  - `sectionId`: int
- **Response Type:**
    ```javascript
    [
      {
        "id": int,
        "sectionId": int,
        "name": string,
        "text": string,
        "isHidden": bool  
      }
    ]
    ```
- **Sample Request:** `GET /courses/1/sections/1/infoPages`
- **Response Codes:**
  - Successfully found course sections: `200 Ok`
    - **Sample Response:**
      ```json
      [
          {
              "id": 1,
              "sectionId": 1,
              "name": "Introduction",
              "text": "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
              "isHidden": true
          }
      ]
      ```
  - Course not found: `404 Not Found` 
### Get Info Page
- **Short Description:** Gets course's section. Can return a hidden section if owner.
- **URL:** `/courses/{courseId}/sections/{sectionId}/infoPages/{infoPageId}`
- **Method:** `GET`
- **Require Authorization:** `optional`
- **Authorized Roles:** `CREATOR`
- **Request Type:**
  - `courseId`: int
  - `sectionId`: int
  - `infoPageId`: int
- **Response Type:**
    ```javascript
    {
      "id": int,
      "sectionId": int,
      "name": string,
      "text": string,
      "isHidden": bool  
    }
    ```
- **Sample Request:** `GET /courses/1/sections/1/infoPages/1`
- **Response Codes:**
  - Successfully found course sections: `200 Ok`
    - **Sample Response:**
      ```json
      {
        "id": 1,
        "sectionId": 1,
        "name": "Introduction",
        "text": "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
        "isHidden": true
      }
      ```
  - Course section not found: `404 Not Found`
  ### Add Info Page
- **Short Description:** Adds a new info page to an owned course's section
- **URL:** `/courses/{courseId}/sections/{sectionId}/infoPages`
- **Method:** `POST`
- **Require Authorization:** `true`
- **Authorized Roles:** `CREATOR`
- **Request Type:**
  - `courseId`: int
  ```javascript
  {
    "name": string,
    "text": string,
  }
  ```
- **Response Type:**
    ```javascript
    {
      "id": int,
      "sectionId": int,
      "name": string,
      "text": string,
      "isHidden": bool  
    }
    ```
- **Sample Request:** `POST /courses/1/sections/1/infoPages`
  ```json
  {
    "name": "A new info page"
    "text": "",
  }
  ```
- **Response Codes:**
  - Successfully found course sections: `200 Ok`
    - **Sample Response:**
      ```json
      {
        "id": 9,
        "sectionId": 1,
        "name": "A new info page",
        "text": "",
        "isHidden": true
      }
      ```
  - Course section not found: `404 Not Found`
  ### Update Info Page
  - **Short Description:** Updates an owned info page
  - **URL:** `/courses/{courseId}/sections/{sectionId}/infoPages/{infoPageId}`
  - **Method:** `PUT`
  - **Require Authorization:** `true`
  - **Authorized Roles:** `CREATOR`
  - **Request Type:**
    - `courseId`: int
    - `sectionId`: int
    ```javascript
    {
      "name": string,
      "text": string,
      "isHidden": bool
    }
    ```
  - **Response Type:**
    ```javascript
    {
      "id": int,
      "sectionId": int,
      "name": string,
      "text": string,
      "isHidden": bool  
    }
    ```
  - **Sample Request:** `PUT /courses/1/sections/1/infoPages/9`
    ```json
    {
      "name": "A new info page",
      "text": "Example text",
      "isHidden": false
    }
    ```
  - **Response Codes:**
    - Successfully found course sections: `201 Created`
      - **Sample Response:**
       ```json
      {
        "id": 9,
        "sectionId": 1,
        "name": "A new info page",
        "text": "Example text",
        "isHidden": true
      }
      ```
    - Info page not found: `404 Not Found`
   ### Delete Info Page
  - **Short Description:** Deletes the specified info page
  - **URL:** `/courses/{courseId}/sections/{sectionId}/infoPages/{infoPageId}`
  - **Method:** `DELETE`
  - **Require Authorization:** `true`
  - **Authorized Roles:** `CREATOR`
  - **Request Type:**
    - `courseId`: int
    - `sectionId`: int
    - `infoPageId`: int
  - **Response Type:** `-`
  - **Sample Request:** `DELETE /courses/1/sections/9/infoPages/15`
  - **Response Codes:**
    - Successfully deleted info page: `204 No Content`
    - Info page not found: `404 Not Found`
