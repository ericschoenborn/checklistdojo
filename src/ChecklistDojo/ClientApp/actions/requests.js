import request from "superagent";

export const getStudentClassificationTypesRequest = (
  baseUrl,
  accessToken,
  district
) => {
  return request
    .get(`${baseUrl}/api/v3/districts/${district}/student-classification-types`)
    .set("authorization", `Bearer ${accessToken}`)
    .then(response => {
      return response.body;
    });
};
