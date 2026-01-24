import { Link } from 'react-router-dom';
import { NewsListItem } from '../../types/news';

interface Props {
  news: NewsListItem;
}

export function NewsCard({ news }: Props) {
  const formattedDate = new Date(news.createdAt).toLocaleDateString('ru-RU', {
    day: 'numeric',
    month: 'long',
    year: 'numeric'
  });

  return (
    <article className="news-card">
      {news.imageUrl && (
        <img 
          src={news.imageUrl} 
          alt={news.title}
          className="news-card-image"
        />
      )}
      <div className="news-card-content">
        {news.categoryName && (
          <span className="news-card-category">{news.categoryName}</span>
        )}
        <h3 className="news-card-title">
          <Link to={`/news/${news.slug}`}>{news.title}</Link>
        </h3>
        <time className="news-card-date">{formattedDate}</time>
      </div>
    </article>
  );
}