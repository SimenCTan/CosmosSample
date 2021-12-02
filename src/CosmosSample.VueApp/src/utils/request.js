import axios from 'axios'
import store from '@/store'
import { getToken } from '@/utils/auth'
import { Message } from 'element-ui'
import router from '@/router';
import { VueAxios } from "./axios";

// create an axios instance
const service = axios.create({
  baseURL: process.env.VUE_APP_BASE_API,
  timeout: 10000
});

// request interceptor
service.interceptors.request.use(config => {
  var token = getToken();
  if (token) {
    config.headers['Authorization'] = `Bearer ${token}`
  }
  return config;
}, error => {
  errorHandler(error);
});

// response interceptor
service.interceptors.response.use(response => {
  if (response.data) {
    if (response.code && response.code !== 0) {
      Message({
        type: 'error',
        duration: 3 * 1000,
        message: response.data.Message || 'Error'
      });
    } else {
      return response.data;
    }
  } else {
    return response;
  }
}, error => {
  errorHandler(error);
});

// 异常处理器
const errorHandler = (error) => {
  if (error.response) {
    if (error.response.status === 401) {
      router.push({ name: "login" });
    }
    if (error.response.status === 403) {
      router.push({ name: "403" });
      return;
    }
    if (error.message === "Network Error") {
      Message({ type: "danger", message: "网络错误，请稍后再试" });
      store.dispatch("logout");
    }
    return Promise.reject(error);
  }

  console.log('err' + error) // for debug
  Message({
    message: error.message,
    type: 'error',
    duration: 5 * 1000
  })
  return Promise.reject(error)
}

const installer = {
  vm: {},
  install(Vue) {
    Vue.use(VueAxios, service);
  }
};

export default service
export { installer as VueAxios, service as axios };
