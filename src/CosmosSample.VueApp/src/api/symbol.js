import request from '@/utils/request'

export const symbolapi = {
  GetDailyQuote: (tscode) => {
    return request({
      method: "get",
      url: `GetDailyQuote/${tscode}`,
    });
  },
};
