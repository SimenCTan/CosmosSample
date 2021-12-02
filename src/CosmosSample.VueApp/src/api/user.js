import request from '@/utils/request'

const user = {
  login(data) {
    return request({
      url: 'Users/Login',
      method: 'post',
      data
    })
  }
}

export default user
