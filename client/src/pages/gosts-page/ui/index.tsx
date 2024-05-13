import { Filter } from 'widgets/filter';
import { GostsTable } from 'widgets/gosts-table';

import styles from './GostsPage.module.scss'
import { gostModel } from 'entities/gost';
import { useGostsWithPagination } from 'entities/gost';
import InfiniteScroll from 'react-infinite-scroll-component';
import {useEffect} from "react";

const GostsPage = () => {
    const {gosts, countFetched, count, setGostParams, fetchGostsData } = useGostsWithPagination('/docs/all-valid')

    useEffect(() => {
        function checkScrollable() {
            const { scrollHeight, clientHeight } =
                document.documentElement;
            const isContentScrollable = scrollHeight > clientHeight;
            console.log(isContentScrollable);
            if (!isContentScrollable && countFetched < count) {
                fetchGostsData();
            }
        }
        checkScrollable();
        window.addEventListener("resize", checkScrollable);
        return () => {
            window.removeEventListener("resize", checkScrollable);
        };
    }, [gosts]);

    return (
        <div className='container contentContainer'>
            <InfiniteScroll
                dataLength={countFetched}
                next={fetchGostsData}
                hasMore={count > countFetched}
                loader={<p style={{textAlign: 'center'}}>
                    <b>Загрузка...</b>
                </p>}
            >
                <section className={styles.filterSection}>
                    <Filter
                        filterSubmit={(filterData: gostModel.GostFields & {name? :string}) => setGostParams(filterData)}
                    />
                </section>
                <section className={styles.gostSection}>
                    <GostsTable gosts={gosts || []} />
                </section>
            </InfiniteScroll>
        </div>
    )
}

export default GostsPage;