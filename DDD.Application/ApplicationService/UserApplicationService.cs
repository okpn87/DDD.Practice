using DDD.Domain;
using DDD.Domain.DomainService;
using DDD.Domain.Entites;
using DDD.Domain.Exceptions;
using DDD.Domain.Factories;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;

namespace DDD.Application.ApplicationService
{
    /// <summary>
    /// ユーザー関連のアプリケーションサービス
    /// </summary>
    public class UserApplicationService
    {
        private readonly IUserFactory userFactory;
        private readonly IUserRepository userRepository;
        private readonly UserService userService;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="userService"></param>
        public UserApplicationService(IUserFactory userFactory, IUserRepository userRepository, UserService userService)
        {
            this.userFactory = userFactory;
            this.userRepository = userRepository;
            this.userService = userService;
        }

        /// <summary>
        /// ユーザー登録
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mailAddress"></param>
        public void Register(UserRegisterCommand command)
        {
            var userName = new UserName(command.Name);
            var mailAddress = new MailAddress(command.MailAddress);
            // ファクトリによってでユーザーのインスタンスを生成する
            var user = userFactory.Create(userName, mailAddress);

            // ドメインサービスを利用してユーザーの重複を確認する
            if (userService.Exists(user))
            {
                throw new CanNotRegisterUserException(user, "ユーザーはすでに存在しています。");
            }

            userRepository.Save(user);
        }

        /// <summary>
        /// ユーザー更新
        /// </summary>
        /// <param name="command"></param>
        public void Update(UserUpdateCommand command)
        {
            var targetId = new UserId(command.Id);
            var user = userRepository.FindById(targetId);

            if(user == null)
            {
                throw new UserNotFoundException(targetId);
            }

            var name = command.Name;
            if (name != null)
            {
                var newUserName = new UserName(name);
                user.ChangeUserName(newUserName);
            }

            var mailAddress = command.MailAddress;
            if(mailAddress != null)
            {
                var newMailAddress = new MailAddress(mailAddress);
                user.ChangeMailAddress(newMailAddress);
            }

            if (userService.Exists(user))
            {
                throw new CanNotRegisterUserException(user, "ユーザーはすでに存在しています。");
            }

            userRepository.Save(user);
        }

        /// <summary>
        /// ユーザー削除
        /// </summary>
        /// <param name="command"></param>
        public void Delete(UserDeleteCommand command)
        {
            var targetId = new UserId(command.Id);
            var user = userRepository.FindById(targetId);

            if(user == null)
            {
                // 対象が存在しない場合は処理成功
                return;
            }

            userRepository.Delete(user);
        }

        /// <summary>
        /// ユーザー取得
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserData Get(string userId)
        {
            var targetId = new UserId(userId);
            var user = userRepository.FindById(targetId);

            if(user == null)
            {
                return null;
            }

            return new UserData(user);
        }
    }
}
