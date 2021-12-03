import request from '@/utils/request'

export const symbolApi = {
  GetDailyQuote: (tscode) => {
    return get(`GetDailyQuote/${tscode}`);
  },
};

export function get(url) {
  return request({ url, method: "get" });
}
