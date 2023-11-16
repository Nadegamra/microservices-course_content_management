# Sections
## Endpoints
### Get Section List
- **Short Description:** Gets course's section list. Returns hidden sections if owner.
- **URL:** `/courses/{courseId}/sections`
- **Method:** `GET`
- **Require Authorization:** `optional`
- **Authorized Roles:** `CREATOR`
- **Request Type:**
  - `courseId`: int
- **Response Type:**
    ```javascript
    [
      {
        "id": int,
        "courseId": int,
        "name": string,
        "description": string,
        "isHidden": bool  
      }
    ]
    ```
- **Sample Request:** `GET /courses/5/sections`
- **Response Codes:**
  - Successfully found course sections: `200 Ok`
    - **Sample Response:**
      ```json
      [
          {
              "id": 1,
              "courseId": 1,
              "name": "Intro",
              "description": "What will be learned in this course",
              "isHidden": false
          },
          {
              "id": 2,
              "courseId": 1,
              "name": "Variables and arithmetic",
              "description": "Introduction to python variables and arithmetic operations",
              "isHidden": true
          },
          {
              "id": 3,
              "courseId": 1,
              "name": "Functions",
              "description": "Python functions",
              "isHidden": true
          }
      ]
      ```
  - Course not found: `404 Not Found`  
### Get Section
- **Short Description:** Gets course's section. Can return a hidden section if owner.
- **URL:** `/courses/{courseId}/sections/{sectionId}`
- **Method:** `GET`
- **Require Authorization:** `optional`
- **Authorized Roles:** `CREATOR`
- **Request Type:**
  - `courseId`: int
  - `sectionId`: int
- **Response Type:**
    ```javascript
    {
      "id": int,
      "courseId": int,
      "name": string,
      "description": string,
      "isHidden": bool  
    }
    ```
- **Sample Request:** `GET /courses/1/sections/1`
- **Response Codes:**
  - Successfully found course sections: `200 Ok`
    - **Sample Response:**
      ```json
      {
          "id": 1,
          "courseId": 1,
          "name": "Intro",
          "description": "What will be learned in this course",
          "isHidden": false
      }
      ```
  - Course section not found: `404 Not Found`
### Add Section
- **Short Description:** Adds a new section to an owned course
- **URL:** `/courses/{courseId}/sections`
- **Method:** `POST`
- **Require Authorization:** `true`
- **Authorized Roles:** `CREATOR`
- **Request Type:**
  - `courseId`: int
  ```javascript
  {
    "name": string,
    "description": string,
  }
  ```
- **Response Type:**
    ```javascript
    {
      "id": int,
      "courseId": int,
      "name": string,
      "description": string,
      "isHidden": bool  
    }
    ```
- **Sample Request:** `POST /courses/1/sections`
  ```json
  {
    "description": "",
    "name": "A new section"
  }
  ```
- **Response Codes:**
  - Successfully found course sections: `201 Created`
    - **Sample Response:**
      ```json
      {
        "id":8,
        "courseId":1,
        "name":"A new section",
        "description":"",
        "isHidden":true
      }

      ```
  - Owned course not found: `404 Not Found` 
### Update Section
  - **Short Description:** Updates an owned section
  - **URL:** `/courses/{courseId}/sections/{sectionId}`
  - **Method:** `PUT`
  - **Require Authorization:** `true`
  - **Authorized Roles:** `CREATOR`
  - **Request Type:**
    - `courseId`: int
    - `sectionId`: int
    ```javascript
    {
      "name": string,
      "description": string,
      "isHidden": bool
    }
    ```
  - **Response Type:**
      ```javascript
      {
        "id": int,
        "courseId": int,
        "name": string,
        "description": string,
        "isHidden": bool  
      }
      ```
  - **Sample Request:** `PUT /courses/1/sections/9`
    ```json
    {
      "name": "Yet another new section",
      "description": "",
      "isHidden": false
    }
    ```
  - **Response Codes:**
    - Successfully found course sections: `200 Ok`
      - **Sample Response:**
        ```json
        {
            "id": 9,
            "courseId": 1,
            "name": "Yet another new section",
            "description": "",
            "isHidden": false
        }
        ```
    - Owned course not found: `404 Not Found`
### Delete Section
  - **Short Description:** Deletes the specified section
  - **URL:** `/courses/{courseId}/sections/{sectionId}`
  - **Method:** `DELETE`
  - **Require Authorization:** `true`
  - **Authorized Roles:** `CREATOR`
  - **Request Type:**
    - `courseId`: int
    - `sectionId`: int
  - **Response Type:** `-`
  - **Sample Request:** `DELETE /courses/1/sections/9`
  - **Response Codes:**
    - Successfully found course sections: `204 No Content`
    - Owned section not found: `404 Not Found`
