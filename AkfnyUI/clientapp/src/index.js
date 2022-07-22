import React, { Suspense } from "react";
import ReactDOM from "react-dom";
import { Provider } from "react-redux";
import Store from "./store/configStore";
// import './assets/fonts/Tajawal/Tajawal-Regular.ttf';

import "./i18n/i18n";

import App from "./App";

ReactDOM.render(
  <Provider store={Store}>
    <Suspense fallback={<div>Loading...</div>}>
      <App />
    </Suspense>
  </Provider>,
  document.getElementById("root")
);
