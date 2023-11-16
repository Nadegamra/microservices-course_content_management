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
        "name": string,
        "description": string,
        "isHidden": bool  
      }
    ]
    ```
- **Sample Request:** `GET /courses/5/sections`
- **Response Codes:**
  - Course successfully created: `200 Ok`
    - **Sample Response:**
      ```json
      {

      }
      ```
### Get Section

### Add Section

### Update Section

### Delete Section
