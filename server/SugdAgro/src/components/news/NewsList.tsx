import { useEffect, useState } from 'react';
import { newsApi } from '../../api/news';
import { NewsListItem } from '../../types/news';
import { PagedResult } from '../../types/common';
import { useLanguage } from '../../context/LanguageContext';
import { NewsCard } from './NewsCard';

interface Props {
  categoryId?: number;
  pageSize?: number;
}

export function NewsList({ categoryId, pageSize = 10 }: Props) {
  const { lang } = useLanguage();
  const [data, setData] = useState<PagedResult<NewsListItem> | null>(null);
  const [page, setPage] = useState(1);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    setLoading(true);
    newsApi.getAll({ page, pageSize, lang, categoryId })
      .then(setData)
      .finally(() => setLoading(false));
  }, [page, lang, categoryId, pageSize]);

  if (loading) return <div>Загрузка...</div>;
  if (!data) return <div>Ошибка загрузки</div>;

  return (
    <div className="news-list">
      <div className="news-grid">
        {data.items.map(item => (
          <NewsCard key={item.id} news={item} />
        ))}
      </div>
      
      {data.totalPages > 1 && (
        <div className="pagination">
          <button 
            disabled={!data.hasPrevious}
            onClick={() => setPage(p => p - 1)}
          >
            Назад
          </button>
          <span>{page} / {data.totalPages}</span>
          <button 
            disabled={!data.hasNext}
            onClick={() => setPage(p => p + 1)}
          >
            Вперёд
          </button>
        </div>
      )}
    </div>
  );
}