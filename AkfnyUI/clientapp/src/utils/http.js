import axios from "axios";

const domain = "https://localhost:5001/";
export const URLS = {
  account: {
    login: "account/Login",
    refreshToken: "account/RefreshToken",
  },
  trainer: {
    all: "odata/trainer",
    getByName: "trainer/GetByTName",
    add: "trainer/Add",
    changeStatus: "trainer/changeStatus",
    delete: "trainer/delete",
  },
  country: {
    all: "odata/country",
  },
  nationality: {
    all: "odata/nationality",
  },
  trainee: {
    all: "odata/trainee",
    getByName: "trainee/GetByTName",
    add: "trainee/Add",
    changeStatus: "trainee/changeStatus",
    delete: "trainee/delete",
  },
  course: {
    all: "odata/course",
    add: "course/Add",
    edit: "course/Edit",
  },
  suggestion: {
    all: "odata/courseSuggestion",
    getByName: "suggestion/GetByTName",
    changeStatus: "suggestion/changeStatus",
  },
  sector: {
    all: "odata/sector",
  },
  field: {
    all: "odata/field",
  },
  suggestionStatus: {
    all: "odata/profferStatus",
  },
  majorInterest: {
    all: "odata/majorInterest",
  },
  subInterest: {
    all: "odata/subInterest",
  },
  gender: {
    all: "odata/sex",
  },
  country: {
    all: "odata/country",
  },
  city: {
    all: "odata/city",
  },
  idType: {
    all: "odata/numberType",
  },
  qualification: {
    all: "odata/qualificationDefine",
    
  }
};

export const GET = function (url) {
  return axios.get(domain + url);
};

export const POST = function (url, data) {
  return axios.post(domain + url, data);
};
