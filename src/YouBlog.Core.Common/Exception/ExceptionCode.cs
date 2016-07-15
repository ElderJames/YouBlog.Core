namespace YouBlog.Core.Common.Exception
{

    public enum RequestExceptionCode
	{
		缺少必要参数 = -100000,
		请求参数为空 = -100001,
		HttpMethod错误 = -100002,
		InputStream为空 = -100003,
		反序列化数据失败 = -100004,
		错误的ContentType = -100005
	}

	/// <summary>
	/// 权限类错误码
	/// </summary>
	public enum AuthorizationExceptionCode
    {
		缺少鉴权参数 = -101000,
		帐号或密码错误 = -101001,
		Token非法 = -101002,
		原密码错误 = -101003,

		认证失败 = -101101,
		该账户已在其他地方登录 = -101102,
		AccessToken过期 = -101103,
		RrefreshToken过期 = -101104,
		邀请码不存在 = -101105,
		邀请码已过期 = -101106,
		找不到对应用户数据 = -101107,
		Token缓存异常 = -101108,

		权限不足 = -101201
	}

    public enum DataBaseExceptionCode
    {
        数据操作执行时出错 = 120000,
        字段验证不通过 =120001,
        并发错误=120002,
        无记录=120003,
        插入时出错=120004,
        更新时出错=120005,
        删除时出错=120006
    }
}

