import userApi from '@/api/user'
import { getToken, getRefreshToken, setToken, removeToken, setRefreshToken, removeRefreshToken } from '@/utils/auth'
import { resetRouter } from '@/router'

const user = {
  state: {
    token: ""
  },
  mutations: {
    SET_TOKEN: (state, token) => {
      state.token = token
    },
  },
  actions: {
    // user login
    login({ commit }, userInfo) {
      return new Promise((resolve, reject) => {
        userApi.login(userInfo).then(response => {
          if (response.code === 0) {
            var token = response.data.accessToken;
            commit('SET_TOKEN', token);
            setToken(token);
            setRefreshToken(response.data.refreshToken);
          }
          resolve(response);
        }).catch(error => {
          reject(error);
        })
      })
    },

    // change passwd
    resetPassword({ commit }, params) {
      return userApi.resetPassword(params).then((resolve, res) => {
        if (res.code === 0) {
          commit('SET_TOKEN', '');
        }
        resolve(res);
      })
    },
    // user logout
    logout({ commit }) {
      return new Promise((resolve) => {
        commit('SET_TOKEN', '');
        removeToken()
        removeRefreshToken();
        resetRouter()
        resolve()
      })
    },
    refreshToken({ commit }) {
      return new Promise((resolve, reject) => {
        const token = getToken();
        const refreshTokenVal = getRefreshToken();
        userApi.refreshToken({
          AccessToken: token,
          RefreshToken: refreshTokenVal
        })
          .then(res => {
            if (res.code && res.code === 0) {
              var data = res.data;
              setToken(data.accessToken);
              setRefreshToken(data.refreshToken);
              commit("SET_TOKEN", data.accessToken);
              resolve(res);
            }
            reject(res);
          })
          .catch(error => {
            reject(error);
          });
      });
    },
    // remove token
    resetToken({ commit }) {
      return new Promise(resolve => {
        removeToken();
        commit('RESET_STATE')
        resolve()
      })
    }
  }
}

export default user
