import Cookies from 'js-cookie'
import { ACCESS_TOKEN, REFRESH_TOKEN } from "@/store/mutation-types";

export function getToken() {
  return Cookies.get(ACCESS_TOKEN)
}

export function setToken(token) {
  return Cookies.set(ACCESS_TOKEN, token)
}

export function removeToken() {
  Cookies.remove(ACCESS_TOKEN)
}

export function getRefreshToken() {
  return Cookies.get(REFRESH_TOKEN);
}

export function setRefreshToken(refreshToken) {
  return Cookies.set(REFRESH_TOKEN, refreshToken);
}

export function removeRefreshToken() {
  Cookies.remove(REFRESH_TOKEN)
}
